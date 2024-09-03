import React from 'react';

function NewsHeader() 
{
  return (
    <div className="mx-auto max-w-screen-sm text-center lg:mb-16 mb-8">
      <h2 className="mb-4 text-3xl lg:text-4xl tracking-tight font-extrabold text-gray-900 dark:text-white">Haberler</h2>
      <p className="font-light text-gray-500 sm:text-xl dark:text-gray-400">
        En son haberleri buradan takip edebilirsiniz.
      </p>
    </div>
  );
};

export default NewsHeader;