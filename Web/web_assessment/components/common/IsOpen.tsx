interface StatusProps {
    isopen: string;
  }

export const IsOpen: React.FC<StatusProps> = ({ isopen }) => {
    if (isopen == "Open") {
      return (
        <div className="bg-green-400 rounded-full pl-4 pr-4 pt-1 pb-1 flex justify-center self-center">
          Open now
        </div>
      );
    }
    return (
      <div className="bg-red-400 rounded-full pl-4 pr-4 pt-1 pb-1 flex justify-center self-center">
        closed
      </div>
    );
  };