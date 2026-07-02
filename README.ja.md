[English](./README.md) | [日本語](./README.ja.md)

# Bluetooth
C#で作ったシンプルなBluetooth操作用CLI。

### コマンド
```powershell
Bluetooth /on      # Bluetoothをオンにする
Bluetooth /off     # Bluetoothをオフにする
Bluetooth /status  # 現在のBluetoothの状態を表示
Bluetooth /help    # 使えるコマンド一覧を表示
```
### 動作の流れ（フローチャート）
---


![Flowchart](Bluetooth.drawio.svg)



---

### ビルド方法
.NET 10 SDKが必要。https://dotnet.microsoft.com/en-us/download/dotnet/10.0 からインストールできる。

リポジトリのルートでPowerShellを開き、以下を実行するだけ。
```powershell
dotnet publish -c Release
```

## AGPL-3.0 ライセンス
参照：https://www.gnu.org/licenses/agpl-3.0.en.html

[OSI承認済み](https://opensource.org/licenses?ls=GNU+Affero+General+Public+License+version+3)のオープンソースライセンス。AGPL-3.0の条件のもとで、自由にフォーク・改変・再配布してもらって構わない。

AGPL-3.0に従う以上、対象コードは同じライセンスのまま維持する必要があり、別のライセンスへの再ライセンスはできない。また、このソフトウェアを受け取った人（購入やサービス経由も含む）には、同じライセンス条件のもとで対応するソースコードへのアクセスを提供する必要がある。

ライセンス全文は[LICENSE.txt](https://github.com/KiyomizuSuzu/Bluetooth/blob/main/LICENSE.txt)を参照。