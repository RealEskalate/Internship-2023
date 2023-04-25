import { FC } from "react";

type ChipProps = {
  label: string;
};

const Chip: FC<ChipProps> = ({ label }) => {
  return (
    <div className="flex items-center px-2 py-1 rounded-full bg-gray-200 text-gray-700 mr-2 mb-2 mx-4 mt-5 ">
      <div className="text-md font-light">{label}</div>
    </div>
  );
};

export default Chip;
