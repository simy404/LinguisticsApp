import React from 'react';
import NewsItem from './NewsItem';

function NewsList({ newsPosts }) 
{
  return (
    <div className="grid gap-8 lg:grid-cols-2 items-start">
      {newsPosts.map((post, index) => (
        <NewsItem key={index} post={post} />
      ))}
    </div>
  );
};

export default NewsList;
