jQuery.extend(jQuery.validator.messages, {
    required: "Bu alanın doldurulması zorunludur.",
    remote: "Lütfen bu alanı düzeltin.",
    email: "Lütfen geçerli bir e-posta adresi girin.",
    url: "Lütfen geçerli bir web adresi (URL) girin.",
    date: "Lütfen geçerli bir tarih girin.",
    dateISO: "Lütfen geçerli bir tarih girin (YYYY-MM-DD).",
    number: "Lütfen geçerli bir sayı girin.",
    digits: "Lütfen sadece rakam girin.",
    creditcard: "Lütfen geçerli bir kredi kartı numarası girin.",
    equalTo: "Lütfen aynı değeri tekrar girin.",
    accept: "Lütfen geçerli uzantıya sahip bir değer girin.",
    maxlength: jQuery.validator.format("Lütfen en fazla {0} karakter girin."),
    minlength: jQuery.validator.format("Lütfen en az {0} karakter girin."),
    rangelength: jQuery.validator.format("Lütfen en az {0} ve en fazla {1} karakter uzunluğunda bir değer girin."),
    range: jQuery.validator.format("Lütfen {0} ile {1} arasında bir değer girin."),
    max: jQuery.validator.format("Lütfen {0} veya daha küçük bir değer girin."),
    min: jQuery.validator.format("Lütfen {0} veya daha büyük bir değer girin.")
});
