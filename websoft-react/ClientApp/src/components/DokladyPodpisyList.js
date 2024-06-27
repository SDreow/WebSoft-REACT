import axios from 'axios';
import React, { useState, useEffect } from 'react';

function DokladyPodpisyList() {
  const [dokladyPodpisy, setDokladyPodpisy] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    axios.get('https://localhost:5064/api/DokladyPodpisy', {
      headers: {
        'Content-Type': 'application/json'
      }
    })
    .then(response => {
      setDokladyPodpisy(response.data);
      setLoading(false);
    })
    .catch(error => {
      setError(error);
      setLoading(false);
    });
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  return (
    <div>
      <h1>Doklady Podpisy List</h1>
      <ul>
        {dokladyPodpisy.map(doklad => (
          <li key={doklad.ID}>
            {doklad.DruhDokladu} - {doklad.CisloDokladu} - {doklad.Castka}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default DokladyPodpisyList;

