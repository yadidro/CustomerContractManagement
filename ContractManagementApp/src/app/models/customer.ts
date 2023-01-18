export interface Address {
  city: string;
  street: string;
  homeNumber: string;
  postalCode: string;
}

export interface Customer {
  id: string;
  firstName: string;
  lastName: string;
  address: Address;
  contracts: Contract[];
}

export interface Contract {
  contractNumber: string;
  contractType: ContractType;
  packages: Package[];
}

export enum ContractType {
  FixedPrice="Fixed Price",
  CostPlus ="Cost Plus",
  TimeAndMaterial="Time And Material"
}

export enum PackageType
{
    Extra="Extra",
    Full="Full",
    Partly="Partly",
}

export interface Package {
  packageType: PackageType;
  packageName: string;
  size: number;
  utilzation: number;
}
