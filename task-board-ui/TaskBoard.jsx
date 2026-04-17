import React, { useState, useEffect } from 'react';
import { apiService } from '../services/api';

const TaskBoard = ({ projectId }) => {
  const [tasks, setTasks] = useState([]);
  const [statusFilter, setStatusFilter] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    fetchTasks();
  }, [projectId, statusFilter, currentPage]);

  const fetchTasks = async () => {
    const response = await apiService.getTasks(projectId, statusFilter, currentPage);
    setTasks(response.data);
    setTotalPages(response.totalPages);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Project Tasks</h2>

      {/* Filter Dropdown */}
      <div style={{ marginBottom: '20px' }}>
        <select onChange={(e) => { setStatusFilter(e.target.value); setCurrentPage(1); }} style={{ padding: '8px' }}>
          <option value="">All Statuses</option>
          <option value="Todo">Todo</option>
          <option value="InProgress">In Progress</option>
          <option value="Done">Done</option>
        </select>
      </div>

      {/* Task List */}
      <div style={{ display: 'flex', flexDirection: 'column', gap: '10px' }}>
        {tasks.map(task => (
          <div key={task.id} style={{ borderBottom: '1px solid #ddd', padding: '10px' }}>
            <strong>{task.title}</strong>
            <p style={{ fontSize: '0.9rem', color: '#666' }}>{task.description}</p>
          </div>
        ))}
      </div>

      {/* Pagination Controls */}
      <div style={{ marginTop: '20px', display: 'flex', gap: '10px', alignItems: 'center' }}>
        <button disabled={currentPage === 1} onClick={() => setCurrentPage(p => p - 1)}>Prev</button>
        <span>Page {currentPage} of {totalPages}</span>
        <button disabled={currentPage === totalPages} onClick={() => setCurrentPage(p => p + 1)}>Next</button>
      </div>
    </div>
  );
};

export default TaskBoard;
