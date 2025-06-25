import axios from 'axios';

const API_URL = 'https://localhost:7018/api/Person';

export const getContacts = async (filters = {}) => {
  const params = new URLSearchParams();
  Object.entries(filters).forEach(([key, value]) => {
    if (value) params.append(key, value);
  });
  
  const response = await axios.get(`${API_URL}/filter`, { params });
  return response.data;
};

export const addContact = async (contact) => {
  return await axios.post(API_URL, contact);
};

export const deleteContact = async (id) => {
  return await axios.delete(`${API_URL}/${id}`);
};