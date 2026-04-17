import React from 'react';

// This component displays a single project summary
const ProjectCard = ({ project }) => {
  return (
    <div style={styles.card}>
      <h3>{project.name}</h3>
      <p>{project.description || "No description provided."}</p>
      
      <div style={styles.stats}>
        <span style={styles.todo}>Todo: {project.todoCount}</span>
        <span style={styles.progress}>In Progress: {project.inProgressCount}</span>
        <span style={styles.done}>Done: {project.doneCount}</span>
      </div>
      
      <button style={styles.button}>View Board</button>
    </div>
  );
};

const styles = {
  card: {
    border: '1px solid #ddd',
    padding: '15px',
    borderRadius: '8px',
    margin: '10px 0',
    backgroundColor: '#fff'
  },
  stats: {
    display: 'flex',
    justifyContent: 'space-between',
    fontSize: '0.8rem',
    marginTop: '10px'
  },
  button: {
    marginTop: '15px',
    padding: '8px',
    width: '100%',
    backgroundColor: '#007bff',
    color: 'white',
    border: 'none',
    borderRadius: '4px'
  }
};

export default ProjectCard;
