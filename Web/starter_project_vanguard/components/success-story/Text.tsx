import React from "react";

interface TextProps {
  heading1: string;
  paragraph: string;
}

const Text: React.FC<TextProps> = ({ heading1, paragraph }) => {
  return (
    <div className="m-8 max-w-3xl">
      <h1 className="font-montserrat text-2xl font-semibold mb-4">{heading1}</h1>
      <p className="font-montserrat italic text-sm">{paragraph}</p>
    </div>
  );
};

export default Text;
