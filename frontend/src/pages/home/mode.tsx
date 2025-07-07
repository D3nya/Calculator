import React from "react";

interface ModeProps {
  name: string;
  description: string;
}

export const Mode: React.FC<ModeProps> = ({ name, description }) => {
  return (
    <div className="p-4 border rounded-md bg-muted/50 shadow-sm">
      <div className="font-medium">{name}</div>
      <div className="text-xs mt-1 text-muted-foreground">{description}</div>
    </div>
  );
};
