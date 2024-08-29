import React from 'react';
import Header from '../components/Header/Header';

function HomePage() 
{
  return (
    <div>
      <Header />
      <div className="container mx-auto p-4">
        <h1 className="text-3xl font-bold text-gray-900 dark:text-white">Welcome to the Home Page</h1>
        <p className="mt-4 text-gray-600 dark:text-gray-300">
          This is the home page content. You can customize this section to display anything you'd like.
        </p>
      </div>
    </div>
  );
};

export default HomePage;
