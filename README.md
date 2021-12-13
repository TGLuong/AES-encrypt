# AES - Encryption, Decryption
## 1. Tổng Quan Về Thuật Toán Mã Hoá AES
Chuẩn mã hóa dữ liệu cao cấp AES là một hệ mã khóa bí mật có tên là **Rijndael** (Do hai nhà mật mã học người Bỉ 
là **Joan Daemen** và **Vincent Rijmen** đưa ra và trở thành chuẩn từ năm 2002) cho phép xử lý các khối dữ liệu input
có kích thước `128bit`, sử dụng các khóa có độ dài `128bit` `192bit` hoặc `256 bit`
### Ví Dụ Mã Hoá Với Khoá 128bit:
Với đầu vào bản rõ có chuỗi bit là:
```C#
{0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66}
```
Giả sử khoá bí mật là:
```C#
{0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66}
```
Bản rõ được mã khoá theo khoá, kết quả thu được bản mã đầu ra là:
```C#
{0x20, 0x5d, 0x1f, 0xc2, 0x71, 0xad, 0xbd, 0xaa, 0x0d, 0xf0, 0x13, 0x4a, 0xaf, 0xce, 0x60, 0xf5}
```
## 2. Chi Tiết Thuật Toán Mã Hoá AES
### 2.1. Dữ Liệu Đầu Vào
Đầu vào của thuật toán được chia thành từng khối dữ liệu `128bit`, và do đặc điểm này, người ta còn gọi AES 
là thuật toán mã hoá khối.</br>
Chuỗi đầu vào được đưa vào ma trận `state [4x4]` theo **qui tắc dọc** với mỗi phần tử của ma trận là 1 byte:</br>
```C#
byte[,] state = {{0x30, 0x34, 0x38, 0x63}
                 {0x31, 0x35, 0x39, 0x64}
                 {0x32, 0x36, 0x61, 0x65}
                 {0x33, 0x37, 0x62, 0x66}}
```
Tương tự như vậy, khoá của thuật toán cũng được lưu vào ma trận `key [4x4]`:
```C#
byte[,] key = {{0x30, 0x34, 0x38, 0x63}
               {0x31, 0x35, 0x39, 0x64}
               {0x32, 0x36, 0x61, 0x65}
               {0x33, 0x37, 0x62, 0x66}}
```
### 2.2. Mô Tả Thuật Toán
Từ ma trận `key`, ta thực hiện hàm `KeyExpansion` để mở rộng khoá, các khoá(_roundkey_) sẽ được sử hàm `AddRoundKey` dụng tại từng vòng mã hoá.</br>
**KeyExpansion:**
 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10| 11| 12| 13| 14| 15| 16| 17| 18| 19| 20| 21| 22| 23| 24| 25| 26| 27| 28| 29| 30| 31| 32| 33| 34| 35| 36| 37| 38| 39| 40| 41| 42| 43
---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---
 30| 34| 38| 63| 7c| 48| 70| 13| d1| 99| e9| fa| 63| fa| 13| e9| 96| 6c| 7f| 96| ff| 93| ec| 7a| 2f| bc| 50| 2a|  1| bd| ed| c7| e1| 5c| b1| 76| af| f3| 42| 34| 72| 81| c3| f7
```
 30 34 38 63 7c 48 70 13 d1 99 e9 fa 63 fa 13 e9 96 6c 7f 96 ff 93 ec 7a 2f bc 50 2a  1 bd ed c7 e1 5c b1 76 af f3 42 34 72 81 c3 f7
 31 35 39 65 72 47 7e 1b 5b 1c 62 79 26 3a 58 21 ec d6 8e af e0 36 b8 17 dc ea 52 45 6d 87 d5 90 2f a8 7d ed  4 ac d1 3c f4 58 89 b5
 32 36 61 64 7f 49 28 4c 3e 77 5f 13 2b 5c  3 10 ce 92 91 81 ef 7d ec 6d aa d7 3b 56 4c 9b a0 f6 c6 5d fd  b bc e1 1c 17 ef  e 12  5
 33 37 62 65 c8 ff 9d f8 b5 4a d7 2f 98 d2  5 2a 86 54 51 7b 16 42 13 68 cc 8e 9d f5 29 a7 3a cf ef 48 72 bd d7 9f ed 50 cf 50 bd ed
```
Attempt | #1 | #2 | #3 | #4 | #5 | #6 | #7 | #8 | #9 | #10 | #11
--- | --- | --- | --- |--- |--- |--- |--- |--- |--- |--- |---
Seconds | 301 | 283 | 290 | 286 | 289 | 285 | 287 | 287 | 272 | 276 | 269
### 2.2.1. Thuật Toán Mã Hoá
Đầu tiên ma trận `state` được cộng với ma trận `key` bằng phép toán `XOR`, sau đó `state` được biến đổi bằng cách thực hiện
một RoundFunction `Nr` lần, mỗi lần sẽ sử dụng một roundkey ở trong bảng KeyExpansion.</br>
`Nr` phụ thuộc vào độ dài khoá là `128bit` `192bit` hoặc `256bit`:
- `128bit` => `Nr` = 10
- `192bit` => `Nr` = 12
- `256bit` => `Nr` = 14

RoundFunction làm một hàm đi thực hiện lần lượt bốn hàm: `SubBytes` `ShiftRows` `MixColumns` `AddRoundKey`.</br>
Riêng vòng cuối cùng thực hiện ba hàm `SubBytes` `ShiftRows` `AddRoundKey`. Trạng thái cuối cùng sẽ được chuyển 
thành đầu ra mã hoá của thuật toán.</br>
_**Lưu ý: code chỉ mang tính chất minh hoạ.**_
```C#
public void Encrypt()
    {
        // state xor key
        AddRoundKey(0);
        for (int i = 1; i < Nr; i++)
        {
            // RoundFunction
            SubBytes();
            ShiftRows();
            MixColumns();
            AddRoundKey(i * 4);
        }
        // Vòng cuối
        SubBytes();
        ShiftRows();
        AddRoundKey(Nr * 4);
    }
```
### 2.2.2. Thuật Toán Giải Mã
Đối với thuật toán giải mã chỉ đơn giản là ta làm ngược lại so với thuật toán giải mã, ta sử dụng bốn hàm ngịch đảo của 
các hàm `SubBytes` `ShiftRows` `MixColumns` `AddRoundKey`, lần lượt là:
- `InvSubBytes`
- `InvShiftRows`
- `InvMixColumns`
- Riêng hàm `AddRoundKey` là nghịch đảo của chính nó vì sử dụng phép `XOR`

Trình tự thực hiện các hàm là ngược lại so với thuật toán mã hoá:
```C#
public void Decrypt()
    {
        AddRoundKey(Nr * 4);
        for (int i = Nr - 1; i >= 1; i--)
        {
            InvShiftRows();
            InvSubBytes();
            AddRoundKey(i * 4);
            InvMixColumns();
        }
        InvShiftRows();
        InvSubBytes();
        AddRoundKey(0);
    }
```

# Reference
- [Giáo trình An toàn và bảo mật thông tin](https://actvneduvn-my.sharepoint.com/:b:/g/personal/ct030433_actvn_edu_vn/EeDoz5wjKZpDjtRVZgIZNxsBz5s_8GviuJQ-rgaNLv_UQA?e=0JJLSM)
- https://github.com/cloudmadeofcandy/AES_implementation
- https://nvlpubs.nist.gov/nistpubs/fips/nist.fips.197.pdf
- https://en.wikipedia.org/wiki/Advanced_Encryption_Standard
- https://en.wikipedia.org/wiki/Rijndael_S-box
- https://en.wikipedia.org/wiki/Rijndael_MixColumns
- https://www.brainkart.com/article/AES-Key-Expansion_8410
### Round Constance 192bit - 256bit
- https://crypto.stackexchange.com/questions/81712/rcon-for-aes-192-and-256