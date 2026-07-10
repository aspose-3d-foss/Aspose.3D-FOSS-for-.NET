#!/usr/bin/env python3
# Script to fix FileFormat.cs

# Step 1: Read the file
with open('src/main/Aspose.ThreeD/Aspose/ThreeD/FileFormat.cs', 'r', encoding='utf-8') as f:
    lines = f.readlines()

print(f"Original file: {len(lines)} lines")

# Step 2: Remove base CanDetect (lines 121-130, 0-indexed: 120-129)
base_can_detect_start = 120  # line 121 (0-indexed)
base_can_detect_end = 129    # line 130 (0-indexed)

print(f"Removing base CanDetect: lines {base_can_detect_start+1}-{base_can_detect_end+1}")
lines = lines[:base_can_detect_start] + lines[base_can_detect_end+1:]
print(f"After removing base CanDetect: {len(lines)} lines")

# Step 3: Find and remove CanDetect overrides (search from end to beginning)
override_regions = []

for i in range(len(lines) - 1, -1, -1):
    if 'public override bool CanDetect' in lines[i]:
        start = i - 2
        if start < 0 or '///' not in lines[start]:
            start = i
        
        brace_count = 0
        found_open = False
        for j in range(i, len(lines)):
            if '{' in lines[j]:
                brace_count += lines[j].count('{')
                found_open = True
            if '}' in lines[j]:
                brace_count -= lines[j].count('}')
            if found_open and brace_count == 0:
                override_regions.append((start, j))
                break

print(f"\nFound {len(override_regions)} CanDetect overrides:")
for start, end in override_regions:
    print(f"  Lines {start+1}-{end+1}")

# Remove overrides in reverse order
for start, end in override_regions:
    print(f"Removing override at lines {start+1}-{end+1}")
    lines = lines[:start] + lines[end+1:]
    print(f"  After removal: {len(lines)} lines")

# Step 4: Modify Detect method
for i in range(len(lines) - 1, -1, -1):
    if 'public static FileFormat Detect(Stream stream, string fileName)' in lines[i]:
        detect_start = i
        brace_count = 0
        for j in range(i, len(lines)):
            if '{' in lines[j]:
                brace_count += lines[j].count('{')
            if '}' in lines[j]:
                brace_count -= lines[j].count('}')
            if brace_count < 0:
                detect_end = j
                break
        
        print(f"\nModifying Detect method: lines {detect_start+1}-{detect_end+1}")
        
        new_detect = [
            "        /// <summary>\n",
            "        /// Detects file format from data stream, file name is optional for guessing types that has no magic header.\n",
            "        /// </summary>\n",
            "        public static FileFormat Detect(Stream stream, string fileName)\n",
            "        {\n",
            "            if (fileName != null)\n",
            "            {\n",
            "                var ext = Path.GetExtension(fileName);\n",
            "                return GetFormatByExtension(ext);\n",
            "            }\n",
            "\n",
            '            throw new ArgumentException("Cannot detect file format without file name");\n',
            "        }\n",
        ]
        
        lines = lines[:detect_start] + new_detect + lines[detect_end+1:]
        print(f"After modifying Detect: {len(lines)} lines")
        break

# Write the result
with open('src/main/Aspose.ThreeD/Aspose/ThreeD/FileFormat.cs', 'w', encoding='utf-8') as f:
    f.writelines(lines)

print(f"\n=== Final: {len(lines)} lines ===")

# Verify
print("\n=== Checking remaining CanDetect occurrences ===")
for i, line in enumerate(lines):
    if 'CanDetect' in line:
        print(f"Line {i+1}: {line.strip()}")
