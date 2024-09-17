import React from 'react';
import HomePage from './pages/HomePage';
import NewsPage from './pages/NewsPage';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './index.css';
import Layout from './components/Layout';
import LinkPage from './pages/LinkPage';
import VideoPage from './pages/VideoPage';

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/news" element={<NewsPage />} />
          <Route path="/link" element={<LinkPage />} />
          <Route path="/video" element={<VideoPage />} />

          {/* Diğer sayfalar için Route bileşenleri ekleyebilirsiniz */}
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;
