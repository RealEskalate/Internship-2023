import React from "react";

const Text = ({
  heading1,
  paragraph,
}: {
  heading1: string;
  paragraph: string;
}) => {
  return (
    <div className="m-8 max-w-3xl">
      <h1 className="font-montserrat text-2xl font-semibold mb-4">{heading1}</h1>
      <p className="font-montserrat italic text-sm">{paragraph}</p>
    </div>
  );
};

export default Text;
