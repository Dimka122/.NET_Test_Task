import React, { useState } from 'react';
import { TextField, Button, Grid, Box } from '@mui/material';

export default function ContactFilter({ onFilter }) {
  const [filters, setFilters] = useState({
    firstName: '',
    lastName: '',
    city: ''
  });

  const handleChange = (e) => {
    setFilters({ ...filters, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onFilter(filters);
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ mb: 3 }}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={4}>
          <TextField
            fullWidth
            label="First Name"
            name="firstName"
            value={filters.firstName}
            onChange={handleChange}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            fullWidth
            label="Last Name"
            name="lastName"
            value={filters.lastName}
            onChange={handleChange}
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            fullWidth
            label="City"
            name="city"
            value={filters.city}
            onChange={handleChange}
          />
        </Grid>
        <Grid item xs={12}>
          <Button type="submit" variant="outlined" fullWidth>
            Apply Filters
          </Button>
        </Grid>
      </Grid>
    </Box>
  );
}