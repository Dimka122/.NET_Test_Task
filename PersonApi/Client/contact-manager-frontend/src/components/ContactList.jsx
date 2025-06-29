import React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, IconButton } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';

export default function ContactList({ contacts, onDelete }) {
  return (
    <TableContainer component={Paper} sx={{ mt: 3 }}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>First Name</TableCell>
            <TableCell>Last Name</TableCell>
             <TableCell>City</TableCell>
            <TableCell>AddressLine</TableCell>
            <TableCell>Email</TableCell>
            
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {contacts.map((contact) => (
            <TableRow key={contact.id}>
              <TableCell>{contact.firstName || '-'}</TableCell>
              <TableCell>{contact.lastName || '-'}</TableCell>
              <TableCell>{contact.address?.city || '-'}</TableCell>
              <TableCell>{contact.address?.addressLine || '-'}</TableCell>
              <TableCell>{contact.email || '-'}</TableCell>
              
              <TableCell>
                <IconButton onClick={() => onDelete(contact.id)}>
                  <DeleteIcon color="error" />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}