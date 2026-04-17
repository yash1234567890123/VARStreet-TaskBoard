import React from 'react';
import Dashboard from './pages/Dashboard';

function App() {
  return (
    <div style={{ fontFamily: 'sans-serif' }}>
      <nav style={{ background: '#2c3e50', color: '#fff', padding: '1rem' }}>
        <h2>VARStreet TaskBoard</h2>
      </nav>
      <Dashboard />
    </div>
  );
}
export default App;
