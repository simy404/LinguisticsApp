import React from 'react';


function NewsSideBar() {

      return (
        <aside className="hidden lg:block lg:w-80" aria-labelledby="sidebar-label">
        <div className="sticky top-36">
          <h3 id="sidebar-label" className="sr-only">Sidebar</h3>
          <div className="lg:ml-auto">
            <script
              id="_carbonads_js"
              src="//cdn.carbonads.com/carbon.js?serve=CK7D4KQE&placement=flowbitedesign"
            />
          </div>
          <div className="p-6 pb-4 mt-6 mb-6 font-medium text-gray-500 bg-white border border-gray-200 rounded-lg dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400">
            <h4 className="mb-4 font-bold text-gray-900 uppercase dark:text-white">Recommended topics</h4>
            <div className="flex flex-wrap">
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/alpine-js/"
              >
                #Alpine.js
              </a>
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/angular/"
              >
                #Angular
              </a>
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/figma/"
              >
                #Figma
              </a>
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/flowbite/"
              >
                #Flowbite
              </a>
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/laravel/"
              >
                #Laravel
              </a>
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/next-js/"
              >
                #Next.js
              </a>
              <a
                className="bg-blue-100 text-blue-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-blue-200 hover:bg-blue-200 dark:hover:bg-blue-300 dark:text-blue-800 mb-2"
                href="/blog/tag/tailwind-css/"
              >
                #Tailwind CSS
              </a>
            </div>
          </div>
  
          <div className="p-6 mb-6 font-medium text-gray-500 bg-white border border-gray-200 rounded-lg dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400">
            <h4 className="mb-4 font-bold text-gray-900 uppercase dark:text-white">Community authors</h4>
            <ul className="space-y-4 text-gray-500 dark:text-gray-400">
              <li>
                <a className="flex items-start" href="/blog/author/david/">
                  <div className="mr-3 shrink-0">
                    <img
                      className="w-6 h-6 mt-1 rounded-full"
                      src="https://publisher.flowbite.com/content/images/2022/12/david-dumont-profile-picture.jpeg"
                      alt="David Dumont profile picture"
                    />
                  </div>
                  <div className="mr-3">
                    <span className="block font-medium text-gray-900 dark:text-white">David Dumont</span>
                    <span className="text-sm">
                      Co-founder at Suncel: a CMS for Next.js apps and websites.
                    </span>
                  </div>
                </a>
              </li>
              <li>
                <a className="flex items-start" href="/blog/author/rich/">
                  <div className="mr-3 shrink-0">
                    <img
                      className="w-6 h-6 mt-1 rounded-full"
                      src="https://publisher.flowbite.com/content/images/2023/01/1605304654466.jpg"
                      alt="Rich Klein profile picture"
                    />
                  </div>
                  <div className="mr-3">
                    <span className="block font-medium text-gray-900 dark:text-white">Rich Klein</span>
                    <span className="text-sm">
                      Technical writer, web developer, and customer success specialist.
                    </span>
                  </div>
                </a>
              </li>
              <li>
                <a className="flex items-start" href="/blog/author/harikrishna/">
                  <div className="mr-3 shrink-0">
                    <img
                      className="w-6 h-6 mt-1 rounded-full"
                      src="https://publisher.flowbite.com/content/images/2022/11/Author-Headshot.jpg"
                      alt="Harikrishna Kundariya profile picture"
                    />
                  </div>
                  <div className="mr-3">
                    <span className="block font-medium text-gray-900 dark:text-white">Harikrishna Kundariya</span>
                    <span className="text-sm">
                      Marketer, developer, IoT, ChatBot & Blockchain savvy, CEO of eSparkBiz.
                    </span>
                  </div>
                </a>
              </li>
            </ul>
          </div>
        </div>
      </aside>
        );
}

export default NewsSideBar;