import React, { ReactNode } from 'react';

interface ImageProps {
  src: string;
  borderRadius?: string;
  className?: string;
}

const Image: React.FC<ImageProps> = ({
  src,
  borderRadius = 'rounded',
  className,
}) => {
  return (
    <div className={className}>
      <img src={src} className={`object-cover ${borderRadius}`} />
      
    </div>
  );
};

export default Image;
