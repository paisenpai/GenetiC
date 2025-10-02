# GenetiC

Convert DNA sequences into mRNA, tRNA, and amino acid chains, a tool for learning molecular biology.

Only the letters `A, T, C, G` are valid; other values will trigger an input validation error.


## About

GenetiC is a console application (written in C#/.NET) that helps learners of molecular biology convert DNA sequences into their corresponding:

- mRNA sequences  
- tRNA anticodons  
- Amino acid chains (via the genetic code translation)

It aims to provide a simple and educational way to see how transcription and translation work, in code form.

## Features

- Accepts a DNA input (string of A, T, C, G)  
- Generates mRNA (by replacing T → U)  
- Derives tRNA anticodons from the mRNA  
- Translates codons into amino acids  
- Validates input (checks for invalid characters)  
- Console-based, easy to run / extend  

## Requirements

- .NET (e.g. .NET 6 or matching runtime)  
- C# compiler / .NET SDK  
- (Optional) An IDE or text editor supporting C# projects  

## Installation & Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/paisenpai/GenetiC.git
   cd GenetiC

2. Restore dependencies and build:

   ```bash
   dotnet restore
   dotnet build

3. Run the application:

   ```bash
   dotnet run --project GenetiC


## Contribute

If you want to contribute, feel free to:

1. Fork the repo  
2. Create a feature branch (`git checkout -b feature/xyz`)  
3. Commit your changes  
4. Open a pull request  


