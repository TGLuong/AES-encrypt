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
### 2.2.1. Thuật Toán Mã Hoá
Đầu tiên ma trận `state` được cộng với ma trận `key` bằng phép toán `XOR`, sau đó `state` được biến đổi bằng cách thực hiện
một `RoundFunction` `Nr` lần.</br>
`Nr` phụ thuộc vào độ dài khoá là `128bit` `192bit` hoặc `256bit`:
- `128bit` => `Nr` = 10
- `192bit` => `Nr` = 12
- `256bit` => `Nr` = 14

Riêng vòng cuối cùng thực hiện khác các lần trước đó. Trạng thái cuối cùng sẽ được chuyển thành đầu ra mã hoá của thuật toán.</br>
```C#
public byte[] Encrypt128bit(byte[] planText, byte[] key)
    {
        int length = plantext.Length;
        if (planText.Length % 16 != 0) length = planText.Length + (16 - planText.Length % 16);
        byte[] result = new byte[length];
        KeyExpantion(4, 10);
        int index = 0;
        int resultIndex = 0;
        while (index < this.planText.Length) 
        {
            for (int m = 0; m < 4; m++)
            {
                for (int n = 0; n < 4; n++)
                {
                    if (index < this.planText.Length)
                    {
                        state[n, m] = this.planText[index];
                        index++;
                    }
                    else
                    {
                        state[n, m] = 0x00;
                    }
                }
            }
            AddRoundKey(0);
            for (int i = 1; i <= 9; i++)
            {
                SubBytes();
                ShiftRows();
                MixColumns();
                AddRoundKey(i * 4);
            }
            SubBytes();
            ShiftRows();
            AddRoundKey(40);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[resultIndex++] = state[j, i];
                }
            }
        }
        return result;
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