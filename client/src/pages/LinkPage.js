import React, { useState, useEffect } from "react";
import axios from "axios";
import TopicItem from "../components/Link/TopicItem";
import LinkHeader from "../components/Link/LinkHeader";

const LinkPage = () => {
  // Veriyi tutmak için state
  const [topics, setTopics] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // useEffect ile sayfa yüklendiğinde veri çekme
  useEffect(() => {
    const fetchData = async () => {
      try {
        // API isteği
        const response = await axios.get("https://localhost:7234/api/LinkTopic"); 
        setTopics(response.data);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) return <p>Yükleniyor...</p>;
  if (error) return <p>Hata: {error}</p>;

  return (
    <section className="bg-white dark:bg-gray-900">
        <div className="py-8 px-4 mx-auto max-w-screen-xl lg:py-16 lg:px-1">
            <LinkHeader />

            {topics.map((topic) => (
                <TopicItem key={topic.id} topic={topic} />
            ))}
        </div>
    </section>
  );
};

export default LinkPage;
