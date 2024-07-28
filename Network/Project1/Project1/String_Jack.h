#pragma once
#include <fstream>

class string_jw
{
public:
	string_jw();
	string_jw(const char* str);
	string_jw(const string_jw& other);
	~string_jw();


	// overload
	string_jw& operator=(const string_jw& other);
	char* operator+(const string_jw& other);
private:
	size_t size;
	char* data;
	// sfsf
	// methods
	size_t str_len_jw(const char* str);
	char* str_copy_jw(char*& str, const char* str_copy);
	char* str_cat_jw(char* str, const char* str_cat);
public:
	const char* c_str() const;
	const size_t length() const;
	// file
	void write_jw(const char* file_path) const;
	void write_Bin_jw(const char* file_path) const;
	void writeAll_Bin_jw(const string_jw* strings, size_t length, const char* file_name) const;
	void read_jw(const char* file_path);
	void read_Bin_jw(const char* file_path);
};




// realization
string_jw::string_jw() : size(0), data(nullptr)
{
}

inline string_jw::string_jw(const char* str)
{
	if (str)
	{
		size_t lenght = str_len_jw(str);
		size = lenght;
		data = new char[lenght + 1];
		str_copy_jw(data, str);
	}
	else {
		data = nullptr;
		size = 0;
	}
}

inline string_jw::string_jw(const string_jw& other)
{
	this->size = other.size;
	this->data = new char[size + 1];
	str_copy_jw(data, other.data);
}

string_jw::~string_jw()
{
	if (data != nullptr)
		delete[] data;
}

// char*'s lenght
inline size_t string_jw::str_len_jw(const char* str)
{
	size_t lenght = 0;
	while (str[lenght] != '\0')
	{
		++lenght;
	}
	return lenght;
}

// copy char* 
inline char* string_jw::str_copy_jw(char*& str, const char* str_copy)
{
	/*char* ptr = str;
	while (*str_copy != '\0') {
		*str = *str_copy;
		str++;
		str_copy++;
	}
	*str = '\0';
	return ptr;*/
	size_t len = str_len_jw(str_copy) + 1;
	char* ptr = new char[len];
	for (size_t i = 0; str_copy[i] != '\0'; i++)
	{
		ptr[i] = str_copy[i];
	}
	ptr[len - 1] = '\0';
	if (str != nullptr)
		delete[] str;
	str = ptr;
	return str;
}

inline char* string_jw::str_cat_jw(char* str, const char* str_cat)
{
	size_t len = str_len_jw(str) + str_len_jw(str_cat);
	char* ptr = new char[len + 1];
	for (size_t i = 0; str[i] != '\0'; i++)
	{
		ptr[i] = str[i];
	}

	for (size_t i = 0; str_cat[i] != '\0'; i++)
	{
		ptr[i + str_len_jw(str)] = str_cat[i];
	}
	ptr[len] = '\0';
	return ptr;
}

inline const char* string_jw::c_str() const
{
	return data;
}

inline const size_t string_jw::length() const
{
	return size;
}

inline void string_jw::write_jw(const char* file_path = "output.txt") const
{
	std::ofstream File(file_path);

	if (File.is_open()) {
		File << this->data;
		File.close();
	}
}

inline void string_jw::write_Bin_jw(const char* file_path = "output.bin") const
{
	std::ofstream File(file_path, std::ios::binary);

	if (File.is_open()) {
		File.write(data, size);
		File.close();
	}
}

inline void string_jw::writeAll_Bin_jw(const string_jw* strings, size_t length, const char* file_name = "outputAll.bin") const
{
	std::ofstream File(file_name, std::ios::binary);

	if (File.is_open()) {
		File.write(reinterpret_cast<char*>(&length), sizeof(length));

		for (size_t i = 0; i < length; ++i) {
			File.write(reinterpret_cast<const char*>(&strings[i]), sizeof(string_jw));
		}
	}
	File.close();
}

inline string_jw& string_jw::operator=(const string_jw& other)
{
	if (this != &other)
	{
		if (data != nullptr)
			delete[] data;
		size = other.size;
		data = new char[size + 1];
		str_copy_jw(data, other.data);
	}
	return *this;
}

inline char* string_jw::operator+(const string_jw& other)
{
	char* newStr = new char[size + other.size + 1];
	newStr = str_cat_jw(data, other.data);
	return newStr;
}
