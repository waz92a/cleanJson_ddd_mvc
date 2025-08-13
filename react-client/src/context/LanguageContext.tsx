import React, { createContext, useState, ReactNode } from 'react';

// Define available languages
const languages = ['JavaScript', 'Python'];

interface LanguageContextValue {
  favoriteLanguage: string;
  toggleLanguage: () => void;
}

export const LanguageContext = createContext<LanguageContextValue | undefined>(undefined);

export function LanguageProvider({ children }: { children: ReactNode }) {
  const [favoriteLanguage, setFavoriteLanguage] = useState<string>(languages[0]);

  const toggleLanguage = () => {
    setFavoriteLanguage(prev =>
      prev === languages[0] ? languages[1] : languages[0]
    );
  };

  return (
    <LanguageContext.Provider value={{ favoriteLanguage, toggleLanguage }}>
      {children}
    </LanguageContext.Provider>
  );
}
