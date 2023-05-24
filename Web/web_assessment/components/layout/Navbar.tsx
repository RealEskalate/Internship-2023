// NavigationBar.tsx
import React from 'react';
import Link from 'next/link';

const NavigationBar: React.FC = () => {
  return (
    <nav>
      <ul>
        <li>
          <Link href="/">Home</Link>
        </li>
      </ul>
    </nav>
  );
};

export default NavigationBar;
