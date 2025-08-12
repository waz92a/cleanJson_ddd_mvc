import React from 'react';
// After running NSwag generation, this path will exist:
import { CleanJsonClient } from './api/client';

export default function App() {
  const [data, setData] = React.useState<any>(null);
  const [error, setError] = React.useState<string | null>(null);

  async function load() {
    try {
      // Use the generated client. Adjust base URL to your API port.
      const client = new CleanJsonClient({ baseUrl: 'https://localhost:7133' });
      const result = await client.clean_Get(); // generated from GET /api/clean
      setData(result);
      setError(null);
    } catch (e: any) {
      setError(e?.message ?? String(e));
    }
  }

  return (
    <div style={{ fontFamily: 'sans-serif', padding: 24 }}>
      <h1>CleanJson Client</h1>
      <button onClick={load}>Fetch & Clean</button>
      {error && <pre style={{ color: 'crimson' }}>Error: {error}</pre>}
      {data && (
        <pre style={{ marginTop: 16 }}>{JSON.stringify(data, null, 2)}</pre>
      )}
    </div>
  );
}
