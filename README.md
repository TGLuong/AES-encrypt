# AES-encrypt
## 1. Tổng quan về thuật toán mã hoá AES
Thuật toán mã hoá AES là viết tắt của **Advanced Encryption Standard**, đây là thuật toán mã hoá từng khối 128bit 
dữ liệu cộng với một khoá bí mật có thể thuộc một trong ba dạng : `128bit` `192bit` hoặc `256bit`</br>
### Ví dụ:
Với đầu vào bản rõ có chuỗi bit là:</br>
```ruby
[0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66]
```</br>
Giả sử khoá bí mật là:</br> `[0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66]`</br>



## Reference
- [Giáo trình An toàn và bảo mật thông tin](https://actvneduvn-my.sharepoint.com/:b:/g/personal/ct030433_actvn_edu_vn/EeDoz5wjKZpDjtRVZgIZNxsBz5s_8GviuJQ-rgaNLv_UQA?e=0JJLSM)
- https://github.com/cloudmadeofcandy/AES_implementation
- https://nvlpubs.nist.gov/nistpubs/fips/nist.fips.197.pdf
- https://en.wikipedia.org/wiki/Advanced_Encryption_Standard
- https://en.wikipedia.org/wiki/Rijndael_S-box
- https://en.wikipedia.org/wiki/Rijndael_MixColumns
- https://www.brainkart.com/article/AES-Key-Expansion_8410
### Round Constance 192bit - 256bit
- https://crypto.stackexchange.com/questions/81712/rcon-for-aes-192-and-256