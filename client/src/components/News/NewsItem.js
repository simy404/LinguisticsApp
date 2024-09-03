import React from 'react';
import NewsMeta from './NewsMeta';
import NewsImage from './NewsImage';

function NewsItem({ post })
{
  return (
    <article className="p-4 bg-white rounded-lg border border-gray-200 shadow-md dark:bg-gray-800 dark:border-gray-700">
      <NewsImage src={post.imagePath} alt={post.translations[0].title} />
      <div className="p-4"></div>
      <NewsMeta category={post.tags} date={post.publicationDate} />
      <h2 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
        <a href={post.sourceLink}>{post.translations[0].title}</a>
      </h2>
      <p className="mb-5 font-light text-gray-500 dark:text-gray-400">{post.translations[0].content}</p>
      <div className="flex justify-between items-center">
        <div className="flex items-center space-x-4">
          <img className="w-7 h-7 rounded-full" src={post.sharedBy.profilePicture} alt={`${post.sharedBy.fullName} avatar`} />
          <span className="font-medium dark:text-white">{post.sharedBy.fullName}</span>
        </div>
        <a href={post.link} className="inline-flex items-center font-medium text-primary-600 dark:text-primary-500 hover:underline">
          Read more
          <svg className="ml-2 w-4 h-4" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fillRule="evenodd" d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z" clipRule="evenodd" /></svg>
        </a>
      </div>
    </article>
  );
};

export default NewsItem;
