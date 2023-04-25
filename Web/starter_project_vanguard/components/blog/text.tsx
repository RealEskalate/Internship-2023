import React from 'react';

interface TextProps {
    size?: 'sm' | 'base' | 'lg' | 'xl' | '2xl' | '3xl' | '4xl' | '5xl' | '6xl';
  family?: 'montserrat';
  children: string;
  color?: 'gray-500' | 'black';
  weight?: 'semibold' | 'medium' | 'bold' | 'light';
  className?: string
}

const Text: React.FC<TextProps> = ({ size = "sm", family = "montserrat", children, color="black" , weight = "medium", className=''}) => {
    const sizes: Record<string, string> = {
        sm: 'text-sm',
        base: 'text-base',
        lg: 'text-lg',
        xl: 'text-xl',
        '2xl': 'text-2xl',
        '3xl': 'text-3xl',
        '4xl': 'text-4xl',
        '5xl': 'text-5xl',
        '6xl': 'text-6xl',
      };

  const families: Record<string, string> = {
    montserrat: 'font-montserrat'
  };
  const colors: Record<string, string> = {
    'gray-500': 'text-gray-500'
  };
  const weights: Record<string, string> = {
    'semibold': 'font-semibold',
    'medium' : 'font-medium',
    'bold' : 'font-bold',
    'light': 'font-light'
  };

  return (
    <span className={`${sizes[size]} ${families[family]} ${colors[color]} ${weights[weight]} ${className}`}>
      {children}
    </span>
  );
};

export default Text;
