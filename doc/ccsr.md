# ソースコード による仕様化

## 業務の関心

  仕様を明示する工夫：データ型(クラス)
  整理(パッケージ)

  ツールで一覧、クラス図を作成 ： JIG

## 実装の関心

## 関心の四象限

| | 入出力 | 計算・判断 |
| --- | --- | --- |
| 業務の関心 | 記録、参照<br>通知、送付 | ビジネスルールに基づく計算・判断<br>(金額、日付、区分、計算式、判定式) |
| 実装の詳細 | 入出力の実装の詳細<br>画面/API/データベース | 計算・判断の実装の詳細<br>組み込み型<br>標準ライブラリ |

## 型

とりうる値の範囲
計算方法(何を受けて何を出力するか？→メソッドで表現)

### 例

金額型、掛け率

金額型は掛け率を使って計算可能。

金額計算の挙動が安定
ソースコードでの金額扱いが明確になる

### 値オブジェクト

| グループ | 例 |
| --- | --- |
| 数値系 | 数量、金額 |
| 日付系 | 予定日、完了日、誕生日 |
| 区分系 | 顧客区分、商品区分、価格区分 |
| 文字列系 | 名称、説明、コード、番号 |

#### コレクションオブジェクト

顧客一覧、購入履歴 etc