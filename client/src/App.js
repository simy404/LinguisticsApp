import React from 'react';
import HomePage from './pages/HomePage';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './index.css';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        {/* Diğer sayfalar için Route bileşenleri ekleyebilirsiniz */}
      </Routes>
    </Router>
  );
}

export default App;
