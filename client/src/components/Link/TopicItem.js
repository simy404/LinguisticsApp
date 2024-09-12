import React from "react";

const TopicItem = ({ topic }) => {
  return (
    <div 
        className= {
            topic.parentId ? "mb-6 p-4 bg-white dark:bg-gray-800 rounded-lg drop-shadow-sm" : "mb-6 p-4 bg-white dark:bg-gray-800 rounded-lg drop-shadow-md"
        }
    >
      <h3
        className="mb-2 text-lg font-semibold text-gray-900 dark:text-white"
      >{topic.title}</h3>

      {/* Links Gösterimi */}
      {topic.links && topic.links.length > 0 && (
        <ul
            className="max-w-md space-y-1 text-gray-700 list-disc list-inside dark:text-black-400 leading-relaxed"
        >
          {topic.links.map((link) => (
            <li key={link.id}>
              <a href={link.url}>{link.description}</a>
            </li>
          ))}
        </ul>
      )}

      {/* recursive olarak alt konuları gösterme */}
      {topic.subTopics && topic.subTopics.length > 0 && (
        <div className="ml-4 mt-5">
          {topic.subTopics.map((subTopic) => (
            <TopicItem key={subTopic.id} topic={subTopic} />
          ))}
        </div>
      )}
    </div>
  );
};

export default TopicItem;
