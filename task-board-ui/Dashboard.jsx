import React, { useState, useEffect } from 'react';
import { apiService } from '../services/api';
import ProjectCard from '../components/ProjectCard';

const Dashboard = () => {
  const [projects, setProjects] = useState([]);
  const [loading, setLoading] = useState(true);

  // This runs as soon as the page opens
  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    try {
      const data = await apiService.getProjects();
      setProjects(data);
    } catch (error) {
      console.error("Failed to fetch projects:", error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: '20px' }}>
      <header style={styles.header}>
        <h1>My Projects</h1>
        <button style={styles.addBtn}>+ New Project</button>
      </header>

      {loading ? (
        <p>Loading your projects...</p>
      ) : (
        <div style={styles.grid}>
          {projects.map(p => (
            <ProjectCard key={p.id} project={p} />
          ))}
          {projects.length === 0 && <p>No projects found. Create one to get started!</p>}
        </div>
      )}
    </div>
  );
};

const styles = {
  header: { display: 'flex', justifyContent: 'space-between', alignItems: 'center' },
  addBtn: { backgroundColor: '#28a745', color: 'white', border: 'none', padding: '10px', borderRadius: '5px', cursor: 'pointer' },
  grid: { marginTop: '20px' }
};

export default Dashboard;
