import React from "react";
import { Story } from '@/types/success-story'


const Text: React.FC<Story> = ({ heading, paragraph }) => {
  return (
    <div className="m-8 max-w-3xl">
      <h1 className="font-montserrat text-2xl font-semibold mb-4">{heading}</h1>
      <p className="font-montserrat italic text-sm">{paragraph}</p>
    </div>
  );
};

export default Text;
