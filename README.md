# ActManager

## DB structure
---
### Таблицы

#### 1. Таблица `Users` (Пользователи)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `Username` TEXT NOT NULL — имя пользователя.
  - `PasswordHash` TEXT NOT NULL — хеш пароля.
  - `Email` TEXT — email для уведомлений.
  - `TaxMode` TEXT NOT NULL DEFAULT 'УСН 6%' — налоговый режим (например, УСН 6%, УСН 15%).
  - `BankSyncToken` TEXT — токен для синхронизации с банком (опционально).
- **Индексы**: Уникальный индекс на `Username`.

#### 2. Таблица `Properties` (Объекты недвижимости)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `UserId` INTEGER NOT NULL — ссылка на владельца (внешний ключ на `Users.Id`).
  - `Name` TEXT NOT NULL — название объекта.
  - `Address` TEXT NOT NULL — адрес.
  - `Type` TEXT NOT NULL — тип (офис, склад и т.д.).
  - `Area` REAL — площадь (кв.м).
  - `PhotoPath` TEXT — путь к фото.
  - `Status` TEXT NOT NULL — статус (сдан, свободен).
  - `Latitude` REAL — широта для карты.
  - `Longitude` REAL — долгота для карты.
- **Внешние ключи**: `UserId` → `Users.Id`.
- **Индексы**: Индекс на `Address`, `Type`, и комбинированный индекс на `Latitude`, `Longitude`.

#### 3. Таблица `Contracts` (Договоры)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `PropertyId` INTEGER NOT NULL — ссылка на объект (внешний ключ на `Properties.Id`).
  - `TenantName` TEXT NOT NULL — имя арендатора.
  - `Room` TEXT — помещение (например, "офис 101").
  - `Amount` REAL NOT NULL — сумма аренды (в месяц).
  - `StartDate` TEXT NOT NULL — дата начала (ISO 8601).
  - `EndDate` TEXT NOT NULL — дата окончания (ISO 8601).
  - `PaymentFrequency` TEXT NOT NULL — периодичность платежей (ежемесячно, ежеквартально).
  - `Status` TEXT NOT NULL — статус (активен, истекает, просрочен, расторгнут).
  - `FilePath` TEXT — путь к файлу договора.
  - `PenaltyRate` REAL — ставка штрафа за просрочку (опционально).
  - `IndexationRate` REAL — ставка индексации (опционально).
- **Внешние ключи**: `PropertyId` → `Properties.Id`.
- **Индексы**: Индекс на `TenantName`, `Status`, `StartDate`, `EndDate`.

#### 4. Таблица `ContractTemplates` (Шаблоны договоров)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `UserId` INTEGER NOT NULL — ссылка на пользователя (внешний ключ на `Users.Id`).
  - `TemplateName` TEXT NOT NULL — название шаблона.
  - `Content` TEXT NOT NULL — текст шаблона с placeholders (например, {TenantName}, {Amount}).
- **Внешние ключи**: `UserId` → `Users.Id`.
- **Индексы**: Индекс на `TemplateName`.

#### 5. Таблица `Payments` (Платежи)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `ContractId` INTEGER NOT NULL — ссылка на договор (внешний ключ на `Contracts.Id`).
  - `Amount` REAL NOT NULL — сумма платежа.
  - `PaymentDate` TEXT NOT NULL — дата платежа (ISO 8601).
  - `DueDate` TEXT NOT NULL — дата ожидаемого платежа (ISO 8601).
  - `Status` TEXT NOT NULL — статус (оплачен, частично оплачен, просрочен).
  - `Source` TEXT NOT NULL DEFAULT 'manual' — источник (manual, bank_sync).
- **Внешние ключи**: `ContractId` → `Contracts.Id`.
- **Индексы**: Индекс на `PaymentDate`, `DueDate`, `Status`.

#### 6. Таблица `Expenses` (Расходы)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `PropertyId` INTEGER NOT NULL — ссылка на объект (внешний ключ на `Properties.Id`).
  - `Category` TEXT NOT NULL — категория (ремонт, коммунальные и т.д.).
  - `Amount` REAL NOT NULL — сумма.
  - `ExpenseDate` TEXT NOT NULL — дата расхода (ISO 8601).
  - `DocumentPath` TEXT — путь к чеку.
  - `OcrText` TEXT — текст, извлечённый через OCR (опционально).
- **Внешние ключи**: `PropertyId` → `Properties.Id`.
- **Индексы**: Индекс на `ExpenseDate`, `Category`.

#### 7. Таблица `Taxes` (Налоги)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `UserId` INTEGER NOT NULL — ссылка на пользователя (внешний ключ на `Users.Id`).
  - `Period` TEXT NOT NULL — период (например, "2025-03").
  - `Income` REAL NOT NULL — доход за период.
  - `Expenses` REAL NOT NULL — расходы за период.
  - `TaxAmount` REAL NOT NULL — сумма налога.
  - `MinTaxAmount` REAL — минимальный налог (для УСН).
  - `Deadline` TEXT NOT NULL — срок оплаты (ISO 8601).
  - `Status` TEXT NOT NULL — статус (рассчитан, оплачен).
- **Внешние ключи**: `UserId` → `Users.Id`.
- **Индексы**: Индекс на `Period`, `Deadline`.

#### 8. Таблица `Notifications` (Уведомления)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `UserId` INTEGER NOT NULL — ссылка на пользователя (внешний ключ на `Users.Id`).
  - `Type` TEXT NOT NULL — тип (просрочка, дедлайн налога, окончание договора).
  - `Message` TEXT NOT NULL — текст уведомления.
  - `EventDate` TEXT NOT NULL — дата события (ISO 8601).
  - `RelatedEntityId` INTEGER — ссылка на связанную сущность (например, Id договора или платежа).
  - `IsRead` INTEGER NOT NULL DEFAULT 0 — прочитано (0 — нет, 1 — да).
- **Внешние ключи**: `UserId` → `Users.Id`.
- **Индексы**: Индекс на `EventDate`, `Type`, `IsRead`.

#### 9. Таблица `Analytics` (Аналитика)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `PropertyId` INTEGER NOT NULL — ссылка на объект (внешний ключ на `Properties.Id`).
  - `Period` TEXT NOT NULL — период (например, "2025-03").
  - `Income` REAL NOT NULL — доход за период.
  - `Expenses` REAL NOT NULL — расходы за период.
  - `Profit` REAL NOT NULL — чистая прибыль.
  - `Profitability` REAL NOT NULL — рентабельность (%).
- **Внешние ключи**: `PropertyId` → `Properties.Id`.
- **Индексы**: Индекс на `Period`.

#### 10. Таблица `BankTransactions` (Банковские транзакции)
- **Поля**:
  - `Id` INTEGER PRIMARY KEY AUTOINCREMENT — уникальный идентификатор.
  - `UserId` INTEGER NOT NULL — ссылка на пользователя (внешний ключ на `Users.Id`).
  - `TransactionId` TEXT NOT NULL — внешний ID транзакции из банка.
  - `Amount` REAL NOT NULL — сумма.
  - `TransactionDate` TEXT NOT NULL — дата транзакции (ISO 8601).
  - `Description` TEXT — описание транзакции.
  - `LinkedPaymentId` INTEGER — ссылка на связанный платёж (внешний ключ на `Payments.Id`, опционально).
- **Внешние ключи**: `UserId` → `Users.Id`, `LinkedPaymentId` → `Payments.Id`.
- **Индексы**: Уникальный индекс на `TransactionId`, индекс на `TransactionDate`.

---

