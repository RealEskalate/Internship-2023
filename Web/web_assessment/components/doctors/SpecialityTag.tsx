import React from "react";

interface SpecialityTagProps {
  title: string;
}
const SpecialityTag: React.FC<SpecialityTagProps> = ({ title }) => {
  return (
    <div className="bg-primary text-primarytext flex flex-shrink-0  justify-center items-center m-1 px-3 py-1 max-w-fit max-h-fit rounded-full cursor-pointer font-medium">
      <div className="text-sm font-semibold">{title}</div>
    </div>
  );
};

export default SpecialityTag;
