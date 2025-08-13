import React, { useState } from 'react';
import { CleanJsonClient } from './api/client';
import { LanguageProvider } from './context/LanguageContext';
import MainSection from './components/MainSection';

export default function App() {
  const [data, setData] = useState<any>(null);
  const [error, setError] = useState<string | null>(null);

  async function load() {
    try {
      const client = new CleanJsonClient('https://localhost:7133');
      const result = await client.clean();
      setData(result);
      setError(null);
    } catch (e: any) {
      setError(e?.message ?? String(e));
    }
  }

  return (
    <LanguageProvider>
      <div style={{ fontFamily: 'sans-serif', padding: 24 }}>
        <h1>CleanJson Client</h1>
        <button onClick={load}>Fetch &amp; Clean</button>
        {error && <pre style={{ color: 'crimson' }}>Error: {error}</pre>}
        {data && (
          <pre style={{ marginTop: 16 }}>{JSON.stringify(data, null, 2)}</pre>
        )}
        <MainSection />
      </div>
    </LanguageProvider>
  );
}
