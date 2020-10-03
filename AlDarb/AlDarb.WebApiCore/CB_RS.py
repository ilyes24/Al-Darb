import numpy as np
import pandas as pd
from matplotlib import pyplot as plt
from sklearn.datasets.samples_generator import make_blobs
from sklearn.cluster import KMeans
from sklearn import metrics
from sklearn.feature_extraction.text import TfidfVectorizer
from scipy.sparse import csr_matrix
from sklearn.neighbors import NearestNeighbors
import operator


def get_rating_course_user(courses_path, ratings_path):
    course_df = pd.read_csv(courses_path)
    rating_df = pd.read_csv(ratings_path)
  
    #drop useless columns 
    #course_df.drop(columns_list, axis = 1)
    #rating_df.drop([columns_list], axis = 1)
    
    #merge 2 dataset on courseID
    df = rating_df.merge(course_df, on = 'courseId')
    
    # Get the ratings per course per user
    pvt = df.pivot_table(index='userId',columns='name',values='rating')
    #convert all NaN to -1.
    pvt.fillna(-1,inplace=True)

    #convert pivot table to sparce matrix
    spm = csr_matrix(pvt)  
    
    return spm, pvt


#returns a list of recommended courses according to similar user's ratings
def make_prediction(userId, courses_path, ratings_path, n_neighbors):
    recommended = []
    spm, pvt = get_rating_course_user(courses_path, ratings_path)
    # Creating, training the model
    nn = NearestNeighbors(algorithm = 'brute')
    nn.fit(spm)
    
    #testing the model
    test = pvt.iloc[userId,:].values.reshape(1,len(pvt.columns))
    distance, suggested = nn.kneighbors(test,n_neighbors=n_neighbors)
    for i in range(len(suggested[0])):
        x = pvt.iloc[suggested[0][i],:].values.reshape(1,len(pvt.columns))
        result = np.where(x >= 3)
        for j in range(len(result[1])):
            course = pvt.iloc[:,result[1][j]].name
            if course not in recommended:
                recommended.append(course)
    return recommended


#return dictionary {id_course: average_rating} of k courses having the best average_rating
def recommend_K_best_courses(recommendedList, courses_path, k):
    courses = pd.read_csv(courses_path)
    courseIds = {}
    for i in (recommendedList):
        ID = (courses.loc[course_df.name==i].courseId).to_string(index=False)
        rate = (courses.loc[course_df.name==i].average).to_string(index=False)
        courseIds[int(ID)] = float(rate)  
    sort = dict(sorted(courseIds.items(), key=operator.itemgetter(1), reverse=True)[:k])
    return sort


def main(userId, courses_path, ratings_path, n_neighbors=7, k=10):
    recommended_list = make_prediction(userId, courses_path, ratings_path, n_neighbors)
    return recommend_K_best_courses(recommended_list, courses_path, k)


if __name__ == "__main__":
    main(userId, courses_path, ratings_path, n_neighbors=7, k=10)