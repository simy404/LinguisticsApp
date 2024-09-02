import React from 'react';
import Header from '../components/Header/Header';

function HomePage() 
{
  return (
  <section className="bg-white dark:bg-gray-900">
    <div className="gap-8 items-center py-8 px-4 mx-auto max-w-screen-xl xl:gap-16 md:grid md:grid-cols-2 sm:py-16 lg:px-6">
      <img className="w-full dark:hidden" src="./hello_world.png" alt="dashboard image" />
      <div className="mt-4 md:mt-0">
        <h2 className="mb-4 text-4xl tracking-tight font-extrabold text-gray-900 dark:text-white">ÖNDEYİŞ</h2>
        <p className="mb-6 font-light text-gray-500 md:text-lg dark:text-gray-400">Dil bilimi, kısaca dilin bilimsel incelemesi olarak tanımlanabilir. Türk Dil Kurumu'nun İnternet'te yayınlanan sözlüğünde ise biraz daha geniş anlamıyla "Dillerin yapısını, gelişmesini, dünyada yayılmasını ve aralarındaki ilişkileri ses, biçim, anlam ve cümle bilgisi bakımından genel veya karşılaştırmalı olarak inceleyen bilim, lisaniyat, lengüistik." ifadesiyle tanımlanmaktadır..</p>
        <a href="#" className="inline-flex items-center text-black outline outline-1 focus:ring-4 focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:focus:ring-primary-900 transition duration-300 ease-in-out transform hover:scale-105 hover:shadow-lg"
        >
          İletişim
          <svg className="ml-2 -mr-1 w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fillRule="evenodd" d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z" clipRule="evenodd" /></svg>
        </a>
      </div>
    </div>
  </section>
  );
};

export default HomePage;
