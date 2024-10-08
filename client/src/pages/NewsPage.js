import React, { useState, useEffect } from 'react';
import axios from 'axios';
import NewsHeader from '../components/News/NewsHeader';
import NewsList from '../components/News/NewsList';
import NewsSearchForm from '../components/News/NewsSearchForm';
import NewsSideBar from '../components/News/NewsSideBar';

function NewsPage() {
 
  const [newsPosts, setNewsPosts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

 
  useEffect(() => {
    const fetchNews = async () => {
      try {
        const response = await axios.get('https://localhost:7234/api/News?languageCode=en'); 
        setNewsPosts(response.data);
        console.log(response.data);
        setLoading(false);
      } catch (err) {
        setError('Error fetching data');
        setLoading(false);
      }
    };

    fetchNews();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <section className="bg-white dark:bg-gray-900">
      <div className="py-8 px-4 mx-auto max-w-screen-2xl lg:py-16 lg:px-1">
        <NewsHeader />
        <div className="flex flex-col lg:flex-row lg:space-x-24">
          <div className="lg:w-10/12">
            <NewsList newsPosts={newsPosts} />
          </div>
  
          <div className="lg:w-2/12 mr-auto">
            <NewsSideBar />
          </div>
        </div>
      </div>
    </section>
  );
  
}


export default NewsPage;

