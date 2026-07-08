import os

jugadores = [
   ("messi.svg", "MESSI", "ARGENTINA", "#75AADB"),
    ("emiliano.svg", "E. MARTÍNEZ", "ARGENTINA", "#75AADB"),
    ("alvarez.svg", "J. ÁLVAREZ", "ARGENTINA", "#75AADB"),
    ("enzo.svg", "E. FERNÁNDEZ", "ARGENTINA", "#75AADB"),
    ("romero.svg", "ROMERO",  "ARGENTINA", "#75AADB"),

    ("vinicius.svg", "VINICIUS JR",  "BRASIL", "#FFDD00"),
    ("rodrygo.svg", "RODRYGO",  "BRASIL", "#FFDD00"),
    ("marquinhos.svg", "MARQUINHOS",  "BRASIL", "#FFDD00"),
    ("alisson.svg", "ALISSON", "BRASIL", "#FFDD00"),
    ("bruno_guimaraes.svg", "B. GUIMARÃES",  "BRASIL", "#FFDD00"),

    ("mbappe.svg", "MBAPPÉ", "FRANCIA", "#0055A4"),
    ("griezmann.svg", "GRIEZMANN", "FRANCIA", "#0055A4"),
    ("tchouameni.svg", "TCHOUAMÉNI", "FRANCIA", "#0055A4"),
    ("theo.svg", "T. HERNÁNDEZ", "FRANCIA", "#0055A4"),
    ("maignan.svg", "MAIGNAN",  "FRANCIA", "#0055A4"),

    ("pedri.svg", "PEDRI",  "ESPAÑA", "#DD0032"),
    ("gavi.svg", "GAVI",  "ESPAÑA", "#DD0032"),
    ("morata.svg", "MORATA", "ESPAÑA", "#DD0032"),
    ("unai.svg", "UNAI SIMÓN", "ESPAÑA", "#DD0032"),
    ("rodri.svg", "RODRI",  "ESPAÑA", "#DD0032"),

    ("musiala.svg", "MUSIALA",  "ALEMANIA", "#000000"),
    ("kimmich.svg", "KIMMICH",  "ALEMANIA", "#000000"),
    ("havertz.svg", "HAVERTZ",  "ALEMANIA", "#000000"),
    ("rudiger.svg", "RÜDIGER", "ALEMANIA", "#000000"),
    ("terstegen.svg", "TER STEGEN", "ALEMANIA", "#000000"),

    ("donnarumma.svg", "DONNARUMMA",  "ITALIA", "#0066CC"),
    ("chiesa.svg", "CHIESA", "ITALIA", "#0066CC"),
    ("barella.svg", "BARELLA", "ITALIA", "#0066CC"),
    ("bastoni.svg", "BASTONI", "ITALIA", "#0066CC"),
    ("raspadori.svg", "RASPADORI",  "ITALIA", "#0066CC"),

    ("cristiano.svg", "C. RONALDO", "PORTUGAL", "#FF0000"),
    ("brunofernandes.svg", "B. FERNANDES",  "PORTUGAL", "#FF0000"),
    ("bernardo.svg", "B. SILVA", "PORTUGAL", "#FF0000"),
    ("leao.svg", "R. LEÃO",  "PORTUGAL", "#FF0000"),
    ("diogocosta.svg", "D. COSTA",  "PORTUGAL", "#FF0000"),

    ("kane.svg", "KANE", "INGLATERRA", "#C8102E"),
    ("bellingham.svg", "BELLINGHAM", "INGLATERRA", "#C8102E"),
    ("saka.svg", "SAKA", "INGLATERRA", "#C8102E"),
    ("foden.svg", "FODEN",  "INGLATERRA", "#C8102E"),
    ("pickford.svg", "PICKFORD", "INGLATERRA", "#C8102E"),

    ("valverde.svg", "VALVERDE",  "URUGUAY", "#6CACE4"),
    ("darwinnunez.svg", "D. NÚÑEZ", "URUGUAY", "#6CACE4"),
    ("araujo.svg", "R. ARAÚJO", "URUGUAY", "#6CACE4"),
    ("gimenez.svg", "J.M. GIMÉNEZ", "URUGUAY", "#6CACE4"),
    ("rochet.svg", "ROCHET", "URUGUAY", "#6CACE4"),

    ("vandijk.svg", "VAN DIJK", "PAÍSES BAJOS", "#FF6600"),
    ("frenkie.svg", "F. DE JONG", "PAÍSES BAJOS", "#FF6600"),
    ("depay.svg", "DEPAY",  "PAÍSES BAJOS", "#FF6600"),
    ("gakpo.svg", "GAKPO",  "PAÍSES BAJOS", "#FF6600"),
    ("verbruggen.svg", "VERBRUGGEN", "PAÍSES BAJOS", "#FF6600"),
]

template = '''<svg width="200" height="280" xmlns="http://www.w3.org/2000/svg">
  <defs>
    <linearGradient id="grad-{id}" x1="0%" y1="0%" x2="0%" y2="100%">
      <stop offset="0%" style="stop-color:{color};stop-opacity:1" />
      <stop offset="100%" style="stop-color:#ffffff;stop-opacity:1" />
    </linearGradient>
  </defs>
  <rect width="200" height="280" fill="url(#grad-{id})" stroke="#333" stroke-width="3" rx="10"/>
  <rect x="10" y="10" width="180" height="200" fill="#ffffff" opacity="0.3" rx="5"/>
  <text x="100" y="110" font-family="Arial, sans-serif" font-size="22" font-weight="bold" fill="#333" text-anchor="middle">{nombre}</text>
  <text x="100" y="160" font-family="Arial, sans-serif" font-size="48" font-weight="bold" fill="#333" text-anchor="middle">{numero}</text>
  <rect x="10" y="220" width="180" height="50" fill="#ffffff" opacity="0.8" rx="5"/>
  <text x="100" y="245" font-family="Arial, sans-serif" font-size="14" font-weight="bold" fill="#333" text-anchor="middle">{pais}</text>
  <text x="100" y="262" font-family="Arial, sans-serif" font-size="12" fill="#666" text-anchor="middle">Mundial 2026</text>
</svg>'''

base_path = "wwwroot/images/jugadores"

for archivo, nombre, numero, pais, color in jugadores:
    svg_content = template.format(
        id=archivo.replace('.svg', ''),
        nombre=nombre,
        numero=numero,
        pais=pais,
        color=color
    )
    
    file_path = os.path.join(base_path, archivo)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(svg_content)
    
    print(f"✓ {archivo}")

print("\n✅ Todas las figuritas generadas exitosamente!")
