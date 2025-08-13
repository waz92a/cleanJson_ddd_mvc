// This is a placeholder for the NSwag-generated client.
// In a real setup, run `npm run generate:client` to regenerate this file.
export class CleanJsonClient {
  private baseUrl?: string;

  constructor(options?: { baseUrl?: string }) {
    this.baseUrl = options?.baseUrl;
  }

  async clean_Get(): Promise<any> {
    const url = `${this.baseUrl ?? ''}/api/clean`;
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`HTTP ${response.status}`);
    }
    return response.json();
  }
}
