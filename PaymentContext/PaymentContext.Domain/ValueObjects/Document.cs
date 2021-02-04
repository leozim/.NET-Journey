using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        private const int CNPJ_LENGTH = 14;
        private const int CPF_LENGTH = 11;

        public Document(string number, EDocumentType documentType)
        {
            Number = number;
            DocumentType = documentType;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido!")
            );
        }

        public string Number { get; private set; }
        public EDocumentType DocumentType { get; private set; }

        private bool Validate()
        {
            if(DocumentType == EDocumentType.CNPJ && Number.Length == CNPJ_LENGTH)
                return true;

            if(DocumentType == EDocumentType.CPF && Number.Length == CPF_LENGTH)
                return true;

            return false;
        }
    }
}