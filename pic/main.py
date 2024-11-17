import os

def get_unique_filenames(directory):
    # Collect all unique filenames
    unique_filenames = set()
    for root, _, files in os.walk(directory):
        for file in files:
            if file.endswith('.png'):
                unique_filenames.add(file)
    return unique_filenames

def rename_files(directory, old_name, new_name):
    # Rename all files with the old_name to new_name
    for root, _, files in os.walk(directory):
        for file in files:
            if file == old_name:
                old_path = os.path.join(root, file)
                new_path = os.path.join(root, new_name)
                os.rename(old_path, new_path)
                print(f'Renamed: {old_path} -> {new_path}')

def main():
    directory = input("Enter the path to the folder containing subfolders with PNGs: ").strip()
    if not os.path.isdir(directory):
        print("Invalid directory path.")
        return
    
    unique_filenames = get_unique_filenames(directory)

    for old_name in unique_filenames:
        new_name = input(f"Enter new name for '{old_name}' (excluding .png extension): ").strip()
        if new_name:  # Only rename if a valid new name is provided
            rename_files(directory, old_name, f"{new_name}.png")

if __name__ == "__main__":
    main()
