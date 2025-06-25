import React, { useState, useEffect } from 'react';
import { getContacts, addContact, deleteContact } from './services/api';
import ContactList from './components/ContactList';
import ContactForm from './components/ContactForm';
import ContactFilter from './components/ContactFilter';
import { Container, Typography, Box } from '@mui/material';

function App() {
  const [contacts, setContacts] = useState([]);
  const [filters, setFilters] = useState({});

  useEffect(() => {
    loadContacts();
  }, [filters]);

  const loadContacts = async () => {
    try {
      const data = await getContacts(filters);
      setContacts(data);
    } catch (error) {
      console.error('Error loading contacts:', error);
    }
  };

  const handleAddContact = async (contact) => {
    await addContact(contact);
    loadContacts();
  };

  const handleDelete = async (id) => {
    await deleteContact(id);
    loadContacts();
  };

  return (
    <Container maxWidth="md">
      <Box my={4}>
        <Typography variant="h4" gutterBottom>
          Contact Manager
        </Typography>
        <ContactFilter onFilter={setFilters} />
        <ContactForm onSubmit={handleAddContact} />
        <ContactList contacts={contacts} onDelete={handleDelete} />
      </Box>
    </Container>
  );
}

export default App;