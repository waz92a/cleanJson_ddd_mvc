import React, { useContext } from 'react';
import { LanguageContext } from '../context/LanguageContext';

export default function MainSection() {
  const context = useContext(LanguageContext);
  if (!context) {
    return null;
  }
  const { favoriteLanguage, toggleLanguage } = context;

  return (
    <div>
      <p id="favoriteLanguage">
        favorite programming language: {favoriteLanguage}
      </p>
      <button id="changeFavorite" onClick={toggleLanguage}>
        toggle language
      </button>
    </div>
  );
}
