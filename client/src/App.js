import React from 'react';
import HomePage from './pages/HomePage';
import NewsPage from './pages/NewsPage';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './index.css';
import Layout from './components/Layout';

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/news" element={<NewsPage />} />
          {/* Diğer sayfalar için Route bileşenleri ekleyebilirsiniz */}
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;
