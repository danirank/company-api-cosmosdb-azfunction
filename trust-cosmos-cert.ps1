$certUrl = "https://localhost:8081/_explorer/emulator.pem"
$certPath = "$PSScriptRoot\emulatorcert.crt"

Write-Host "Downloading certificate..."
Invoke-WebRequest -Uri $certUrl -OutFile $certPath -SkipCertificateCheck

# Läs in certet från fil
$newCert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($certPath)

# Kolla om certet redan finns (matcha thumbprint)
$existing = Get-ChildItem Cert:\LocalMachine\Root |
    Where-Object { $_.Thumbprint -eq $newCert.Thumbprint }

if ($existing) {
    Write-Host "Certificate already installed ✔"
}
else {
    Write-Host "Installing certificate..."
    Import-Certificate `
        -FilePath $certPath `
        -CertStoreLocation Cert:\LocalMachine\Root | Out-Null

    Write-Host "Certificate installed ✔"
}

Write-Host "Done"