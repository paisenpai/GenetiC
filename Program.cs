using System;
using System.Collections.Generic;

namespace GenetiC
{
    class DNA
    {
        public static string GetComplement(string seq)  // future update, automatically removes spaces from input
        {
            char[] complement = new char[seq.Length];
            for (int i = 0; i < seq.Length; i++)
            {
                switch (seq[i])
                {
                    case 'A': complement[i] = 'T'; break;
                    case 'T': complement[i] = 'A'; break;
                    case 'C': complement[i] = 'G'; break;
                    case 'G': complement[i] = 'C'; break;
                    default: complement[i] = 'N'; break;
                }
            }
            return new string(complement);
        }

        public static string TranscribeToMRNA(string seq)
        {
            char[] mrna = new char[seq.Length];
            for (int i = 0; i < seq.Length; i++)
            {
                switch (seq[i])
                {
                    case 'A': mrna[i] = 'U'; break;
                    case 'T': mrna[i] = 'A'; break;
                    case 'C': mrna[i] = 'G'; break;
                    case 'G': mrna[i] = 'C'; break;
                    default: mrna[i] = 'N'; break;
                }
            }
            return new string(mrna);
        }
    }

    class RNA
    {
        public static string GetAnticodon(string mrna)
        {
            char[] trna = new char[mrna.Length];
            for (int i = 0; i < mrna.Length; i++)
            {
                switch (mrna[i])
                {
                    case 'A': trna[i] = 'T'; break;
                    case 'T': trna[i] = 'A'; break;
                    case 'C': trna[i] = 'G'; break;
                    case 'G': trna[i] = 'C'; break;
                    default: trna[i] = 'N'; break;
                }
            }
            return new string(trna);
        }

        public static List<string> SplitToCodon(string seq)
        {
            List<string> codons = new List<string>();
            for (int i = 0; i < seq.Length; i += 3)
            {
                if (i + 3 <= seq.Length)
                {
                    codons.Add(seq.Substring(i, 3));
                }
            }
            return codons;
        }
    }

    class CodonTable
    {
        private static readonly Dictionary<string, string> codonMap = new Dictionary<string, string>()
        {
            // Phenylalanine
            { "UUU", "Phenylalanine" }, { "UUC", "Phenylalanine" },

            // Leucine
            { "UUA", "Leucine" }, { "UUG", "Leucine" },
            { "CUU", "Leucine" }, { "CUC", "Leucine" }, { "CUA", "Leucine" }, { "CUG", "Leucine" },

            // Isoleucine
            { "AUU", "Isoleucine" }, { "AUC", "Isoleucine" }, { "AUA", "Isoleucine" },

            // Methionine (Start)
            { "AUG", "Methionine (START)" },

            // Valine
            { "GUU", "Valine" }, { "GUC", "Valine" }, { "GUA", "Valine" }, { "GUG", "Valine" },

            // Serine
            { "UCU", "Serine" }, { "UCC", "Serine" }, { "UCA", "Serine" }, { "UCG", "Serine" },
            { "AGU", "Serine" }, { "AGC", "Serine" },

            // Proline
            { "CCU", "Proline" }, { "CCC", "Proline" }, { "CCA", "Proline" }, { "CCG", "Proline" },

            // Threonine
            { "ACU", "Threonine" }, { "ACC", "Threonine" }, { "ACA", "Threonine" }, { "ACG", "Threonine" },

            // Alanine
            { "GCU", "Alanine" }, { "GCC", "Alanine" }, { "GCA", "Alanine" }, { "GCG", "Alanine" },

            // Tyrosine
            { "UAU", "Tyrosine" }, { "UAC", "Tyrosine" },

            // Histidine
            { "CAU", "Histidine" }, { "CAC", "Histidine" },

            // Glutamine
            { "CAA", "Glutamine" }, { "CAG", "Glutamine" },

            // Asparagine
            { "AAU", "Asparagine" }, { "AAC", "Asparagine" },

            // Lysine
            { "AAA", "Lysine" }, { "AAG", "Lysine" },

            // Aspartic Acid
            { "GAU", "Aspartic Acid" }, { "GAC", "Aspartic Acid" },

            // Glutamic Acid
            { "GAA", "Glutamic Acid" }, { "GAG", "Glutamic Acid" },

            // Cysteine
            { "UGU", "Cysteine" }, { "UGC", "Cysteine" },

            // Tryptophan
            { "UGG", "Tryptophan" },

            // Arginine
            { "CGU", "Arginine" }, { "CGC", "Arginine" }, { "CGA", "Arginine" }, { "CGG", "Arginine" },
            { "AGA", "Arginine" }, { "AGG", "Arginine" },

            // Glycine
            { "GGU", "Glycine" }, { "GGC", "Glycine" }, { "GGA", "Glycine" }, { "GGG", "Glycine" },

            // Stop codons
            { "UAA", "STOP" }, { "UAG", "STOP" }, { "UGA", "STOP" }
        };

        public static List<string> Translate(List<string> codons)
        {
            List<string> aminoAcids = new List<string>();
            foreach (var codon in codons)
            {
                if (codonMap.ContainsKey(codon))
                {
                    string aminoacidPlaceholder = codonMap[codon];
                    aminoAcids.Add(aminoacidPlaceholder);
                    if (aminoacidPlaceholder == "STOP") break;  // Display STOP before terminating the translation.
                }
                else
                {
                    aminoAcids.Add("Unknown");
                }
            }
            return aminoAcids;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the DNA leading strand: ");
            string dna = Console.ReadLine().ToUpper();

            Console.WriteLine("to me... crazy frog is just normal frog...");

            string compDNA = DNA.GetComplement(dna);
            Console.WriteLine("Complementary DNA: " + compDNA);

            string mrna = DNA.TranscribeToMRNA(compDNA);
            Console.WriteLine("mRNA: " + mrna);

            string trna = RNA.GetAnticodon(mrna);
            Console.WriteLine("tRNA: " + trna);

            List<string> codons = RNA.SplitToCodon(mrna);
            Console.WriteLine("mRNA Codons: " + string.Join(", ", codons));

            List<string> aminoAcids = CodonTable.Translate(codons);
            Console.WriteLine("Amino Acid Sequence: " + string.Join(" - ", aminoAcids));        
        }
    }
}