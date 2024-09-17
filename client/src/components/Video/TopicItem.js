import React from "react";

const TopicItem = ({ topic }) => {
  return (
    <div 
        className= "mb-6 p-4 bg-white dark:bg-gray-800 rounded-lg drop-shadow-md"
    >
      <h3
        className="mb-2 text-lg font-semibold text-gray-900 dark:text-white"
      >{topic.title}</h3>

      {/* Links Gösterimi */}
      {topic.videoLinks && topic.videoLinks.length > 0 && (
        <ul
            className="max-w-md space-y-1 text-gray-700 list-disc list-inside dark:text-black-400 leading-relaxed"
        >
          {topic.videoLinks.map((link) => (
            <li key={link.id}>
              <a href={link.url}>{link.description}</a>
            </li>
          ))}
        </ul>
      )}

    </div>
  );
};

export default TopicItem;
