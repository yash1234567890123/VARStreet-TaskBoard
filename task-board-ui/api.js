// This is the base URL where your C# Backend will run
const API_BASE_URL = "http://localhost:5000/api"; 

export const apiService = {
  // Get all projects for the Dashboard
  getProjects: async () => {
    const response = await fetch(`${API_BASE_URL}/projects`);
    return await response.json();
  },

  // Get tasks for a specific project with filtering
  getTasks: async (projectId, status = '', page = 1) => {
    const response = await fetch(
      `${API_BASE_URL}/tasks?projectId=${projectId}&status=${status}&page=${page}`
    );
    return await response.json();
  },

  // Create a new project
  createProject: async (projectData) => {
    const response = await fetch(`${API_BASE_URL}/projects`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(projectData)
    });
    return await response.json();
  }
};
