import React from 'react';
import Image from 'next/image'

interface AvatarProps {
  src: string;
  alt: string;
  size?: 'sm' | 'md' | 'lg';
}

const Avatar: React.FC<AvatarProps> = ({ src, alt, size = 'md' }) => {
  const sizes = {
    sm: 'h-8 w-8',
    md: 'h-12 w-12',
    lg: 'h-20 w-20',
  };

  return (
    <Image
      src={src}
      alt={alt}
      width={12}
      height={12}
      className={`rounded-full ${sizes[size]} object-cover `}
    />
  );
};

export default Avatar;
